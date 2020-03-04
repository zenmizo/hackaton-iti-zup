//
//  ProductCollectionCellCollectionViewCell.swift
//  hackaton-iOS
//
//  Created by Zendji Mizoguchi on 04/03/20.
//  Copyright © 2020 Zendji Mizoguchi. All rights reserved.
//

import UIKit
import BeagleUI

class ProductCollectionCell: UICollectionViewCell {
    
    var currentContainerView: UIView?
   
    @IBOutlet weak var labelName: UILabel!
    @IBOutlet weak var labelDescription: UILabel!
    @IBOutlet weak var image: UIImageView!
    @IBOutlet weak var labelPrice: UILabel!
    
    override func sizeThatFits(_ size: CGSize) -> CGSize {
        return size
    }
    
    func setupCell(with product: Product,
                   beagleContext: BeagleContext,
                   renderableDependencies: RenderableDependencies) {
//        self.contentView.backgroundColor = UIColor(red:0.95, green:0.95, blue:0.95, alpha:1.0)
//        self.labelName.text = product.name
//        self.labelDescription.text = product.description
//        self.image.pathImage(product.imagePath)
//        self.labelPrice.text = product.name
        
        self.labelName.text = ""
        self.labelDescription.text = ""
        self.labelPrice.text = ""
        
        self.yoga.isEnabled = true

        var children: [ServerDrivenComponent] = []
        children.append(Text(product.name))
        children.append(Text(product.description))
//        children.append(NetworkImage(path: product.imagePath))

        let size = Flex.Size(width: UnitValue(value: 100, type: .real), height: UnitValue(value: 100, type: .real))

        let containerCell = Container(children: children, flex: Flex(size: size))
        let viewCell = containerCell.toView(context: beagleContext, dependencies: renderableDependencies)
        
        self.addSubview(viewCell)
        
        
    }
    
}
