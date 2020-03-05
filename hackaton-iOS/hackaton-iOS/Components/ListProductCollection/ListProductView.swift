//
//  ListProductView.swift
//  hackaton-iOS
//
//  Created by Zendji Mizoguchi on 04/03/20.
//  Copyright © 2020 Zendji Mizoguchi. All rights reserved.
//

import UIKit
import BeagleUI

class ListProductView: UIView, UICollectionViewDataSource {
    
    var products: [Product] = []
    var beagleContext: BeagleContext?
    var beagleDependencies: RenderableDependencies?
    
    var collectionView: UICollectionView = {
        let layout = UICollectionViewFlowLayout()
        layout.itemSize = CGSize(width: 190, height: 227)
        layout.sectionInset = UIEdgeInsets(top: 0, left: 12.0, bottom: 0, right: 12.0)
        let collectionView = UICollectionView(frame: CGRect.zero, collectionViewLayout: layout)
        collectionView.translatesAutoresizingMaskIntoConstraints = false
        collectionView.backgroundColor = .clear
        collectionView.isUserInteractionEnabled = true
       return collectionView
    }()
    
    init(context: BeagleContext, beagleDependencies: RenderableDependencies) {
        super.init(frame: .zero)
        self.beagleContext = context
        self.beagleDependencies = beagleDependencies
        setupViewLayout()
    }
    
    
    required init?(coder: NSCoder) {
        fatalError("init(coder:) has not been implemented")
    }
    
    func setupViewLayout() {
        addSubview(collectionView)
        
        [collectionView.topAnchor.constraint(equalTo: topAnchor),
         collectionView.leadingAnchor.constraint(equalTo: leadingAnchor),
         collectionView.bottomAnchor.constraint(equalTo: bottomAnchor),
         collectionView.trailingAnchor.constraint(equalTo: trailingAnchor)
        ].forEach { $0.isActive = true }
        collectionView.delegate = self
        collectionView.dataSource = self
        registerCells()
    }
    
    func registerCells() {
        self.collectionView.register(UINib(nibName: "ProductCollectionCell", bundle: nil), forCellWithReuseIdentifier: "ProductCollectionCell")
    }
    
    func show(_ products: [Product]) {
        
        self.products = products
        self.collectionView.reloadData()
        
        self.next
    }
  
}

extension ListProductView {
    
    func collectionView(_ collectionView: UICollectionView, numberOfItemsInSection section: Int) -> Int {
        return products.count
    }
    
    func collectionView(_ collectionView: UICollectionView, cellForItemAt indexPath: IndexPath) -> UICollectionViewCell {
        
        if let cell = collectionView.dequeueReusableCell(
            withReuseIdentifier: "ProductCollectionCell",
            for: indexPath) as? ProductCollectionCell,
            let context = self.beagleContext,
            let dep = self.beagleDependencies {
            cell.setupCell(with: self.products[indexPath.row],
                           beagleContext: context,
                           renderableDependencies: dep)
            return cell
        }
        
        return UICollectionViewCell()
    }

}

extension ListProductView: UICollectionViewDelegate {
    
    func collectionView(_ collectionView: UICollectionView, didSelectItemAt indexPath: IndexPath) {
        if let currentViewController = self.findViewController()?.navigationController {
            var detailProductViewCotroller = BeagleScreenViewController(
                viewModel: .init(screenType: .remote("\(BeagleSetting.Routes.productDescription.path)\(products[indexPath.row].sku)", fallback: nil)))
            currentViewController.pushViewController(detailProductViewCotroller, animated: true)
        }
    }
    
}
